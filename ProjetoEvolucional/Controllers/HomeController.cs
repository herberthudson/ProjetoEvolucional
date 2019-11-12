using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEvolucional.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ProjetoEvolucional.Controllers
{
    [Authorize]

    public class HomeController: Controller
    {

        private readonly ProjetoEvolucionalDataContext _context;

        public HomeController(ProjetoEvolucionalDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inserir()
        {
            if (!_context.Disciplinas.Any())
            {
                _context.Disciplinas.AddRange(new List<Models.Disciplina>(){
                    new Models.Disciplina(){ Titulo = "Matemática" },
                    new Models.Disciplina(){ Titulo = "Português" },
                    new Models.Disciplina(){ Titulo = "História" },
                    new Models.Disciplina(){ Titulo = "Geografia" },
                    new Models.Disciplina(){ Titulo = "Inglês" },
                    new Models.Disciplina(){ Titulo = "Biologia" },
                    new Models.Disciplina(){ Titulo = "Filosofia" },
                    new Models.Disciplina(){ Titulo = "Física" },
                    new Models.Disciplina(){ Titulo = "Química" }
                });

                _context.SaveChanges();
            }


            var disciplinas = _context.Disciplinas.ToList();
            var alunos = new List<Models.Aluno>();
            var notas = new List<Models.Avaliacao>();

            for (int i = 0; i < 1000; i++)
            {
                alunos.Add( new Models.Aluno() {
                    Nome = "Jose" + i.ToString()
               });

            }

            _context.Alunos.AddRange(alunos);
            _context.SaveChanges();

            foreach (var aluno in _context.Alunos.ToList())
            {
                decimal media = 0;
                foreach (var disciplina in _context.Disciplinas.ToList())
                {
                    decimal nota = (decimal)new Random().Next(0, 10);
                    notas.Add(new Models.Avaliacao()
                    {
                        AlunoId = aluno.Id,
                        DisciplinaId = disciplina.Id,
                        Nota = nota
                    });

                    media += nota;
                }

                aluno.Media = media / 9;
            }

            _context.Avalicaoes.AddRange(notas);
            _context.SaveChanges();

            ViewBag.Inserido = "Dados Inseridos";

            return Redirect("Index");
        }

        public  IActionResult Gerar()
        {
            byte[] filecontents;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet 1");

                worksheet.Cells[1, 1].Value = "Aluno";
                worksheet.Cells[1, 2].Value = "Disciplina";
                worksheet.Cells[1, 3].Value = "Nota";
                worksheet.Cells[1, 4].Value = "Média";

                var notas = _context.Avalicaoes.Include(a=> a.Aluno).Include(d => d.Disciplina).OrderBy(al => al.Id).ToArray();

                for (int i = 0; i < notas.Count(); i++)
                {
                    int pos = i + 2;
                    worksheet.Cells[pos, 1].Value = notas[i].Aluno.Nome;
                    worksheet.Cells[pos, 2].Value = notas[i].Disciplina.Titulo;
                    worksheet.Cells[pos, 3].Value = notas[i].Nota;
                    worksheet.Cells[pos, 4].Value = notas[i].Aluno.Media;
                }

                filecontents = package.GetAsByteArray();
            }

            var filename = "Relatorio-" + DateTime.Now.ToString("yyyymmdd-hhmmss") + ".xlsx";
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\relatorios", filename);

            System.IO.File.WriteAllBytes(filepath, filecontents);

            ViewBag.File = filename;

            return View();
        }

        public IActionResult Download(string file)
        {
            if (file != null)
            {
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\relatorios", file);

                byte[] filecontents = System.IO.File.ReadAllBytes(filepath);

                return File(
                    filecontents,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    file);
            }

            return View();
        }
    }
}
