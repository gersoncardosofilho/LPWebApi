using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LPWebApi.DbContext;
using LPWebApi.Models;

namespace LPWebApi.Controllers
{
    public class PublicacoesController : ApiController
    {
        private PublicacoesContext db = new PublicacoesContext();

        // GET: api/Publicacoes
        public IQueryable<Publicacao> GetPublicacoes()
        {
            return db.Publicacoes;
        }

        // GET: api/Publicacoes/5
        [ResponseType(typeof(Publicacao))]
        public IHttpActionResult GetPublicacao(int id)
        {
            Publicacao publicacao = db.Publicacoes.Find(id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return Ok(publicacao);
        }

        // PUT: api/Publicacoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublicacao(int id, Publicacao publicacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publicacao.IdPublicacao)
            {
                return BadRequest();
            }

            db.Entry(publicacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Publicacoes
        [ResponseType(typeof(Publicacao))]
        public IHttpActionResult PostPublicacao(Publicacao publicacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Publicacoes.Add(publicacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = publicacao.IdPublicacao }, publicacao);
        }

        // DELETE: api/Publicacoes/5
        [ResponseType(typeof(Publicacao))]
        public IHttpActionResult DeletePublicacao(int id)
        {
            Publicacao publicacao = db.Publicacoes.Find(id);
            if (publicacao == null)
            {
                return NotFound();
            }

            db.Publicacoes.Remove(publicacao);
            db.SaveChanges();

            return Ok(publicacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublicacaoExists(int id)
        {
            return db.Publicacoes.Count(e => e.IdPublicacao == id) > 0;
        }
    }
}