using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flink.Application.Requests
{
    public class PutCursoRequest
    {
        public int Codigo { get; set; }
        public string NombreCurso { get; set; } = null!;
        public string UrlCurso { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public TimeSpan Duracion { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoCurso { get; set; }
        public string? Categoria { get; set; }
    }
}
