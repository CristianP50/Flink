﻿using Flink.Domain.Inferfaces;
using Flink.Infraestructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flink.Infraestructure.Repositories
{
    public class UsuarioCursoRepository : IUsuarioCursoRepository
    {
        private FlinkContext _context;

        public UsuarioCursoRepository(FlinkContext context)
        {
            _context=context;
        }

        public IEnumerable<UsuarioCurso> GetUsuarioCursos()
        {
            return _context.UsuarioCursos;
        }

        public UsuarioCurso GetUsuariosCursoById(int id)
        {
            return _context.UsuarioCursos.FirstOrDefault(x => x.UsuarioCursoId == id);
        }


        public void InsertUsuarioCurso(UsuarioCurso usuarioCurso)
        {
            _context.UsuarioCursos.Add(usuarioCurso);
            _context.SaveChanges();
        }

        public void UpdateUsuarioCurso(UsuarioCurso usuariocurso)
        {

            var DataUsuarioCurso = _context.UsuarioCursos.FirstOrDefault(x => x.UsuarioCursoId == usuariocurso.IdUsuario);
            DataUsuarioCurso.UsuarioCursoId = usuariocurso.UsuarioCursoId;
            DataUsuarioCurso.CodigoCurso = usuariocurso.IdUsuario;
            DataUsuarioCurso.IdUsuario = usuariocurso.IdUsuario;
            _context.SaveChanges();
        }

        public void DeleteUsuarioCurso(int id)
        {
            var returnUsuariocurso = _context.UsuarioCursos.FirstOrDefault(x => x.UsuarioCursoId == id);
            _context.UsuarioCursos.Remove(returnUsuariocurso);
            _context.SaveChanges();
        }

    }
}
