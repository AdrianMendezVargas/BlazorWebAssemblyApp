using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorWebAssemblyApp.Shared.Entidades {
    public class Persona {

        public int PersonaId { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
