﻿using Flink.Infraestructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flink.Domain.Inferfaces
{
        public interface IUsuarioRepository
        {
           
        IEnumerable<Usuario> GetUsuarios();
        IEnumerable<Usuario> GetUsuarios(int id);

         void InsertUsuario(Usuario usuario);
         }
    
}
