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
        private AlunoAplicacao appAluno;

        public AlunoController()
        {
            appAluno = AlunoAplicacaoConstrutor.AlunoAplicacaoEF();
        }

        public ActionResult Index()
        {
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
                appAluno.Salvar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public ActionResult Edit(string id)
        {
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
                appAluno.Salvar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public ActionResult Details(string id)
        {
            var aluno = appAluno.getById(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        public ActionResult Delete(string id)
        {
            var aluno = appAluno.getById(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(string id)
        {
            var aluno = appAluno.getById(id);
            appAluno.Delete(aluno);
            return RedirectToAction("Index");
        }
    }
}