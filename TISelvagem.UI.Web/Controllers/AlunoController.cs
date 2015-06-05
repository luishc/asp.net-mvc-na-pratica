using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TISelvagem.Aplicacao;
using TISelvagem.Dominio;

namespace TISelvagem.UI.Web.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            var appAluno = new AlunoAplicacao();
            var listaDeAlunos = appAluno.List();
            return View(listaDeAlunos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Salvar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public ActionResult Edit(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.getById(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Salvar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public ActionResult Details(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.getById(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        public ActionResult Delete(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.getById(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var appAluno = new AlunoAplicacao();
            appAluno.Delete(id);
            return RedirectToAction("Index");
        }
    }
}