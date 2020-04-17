using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Client.Helpers {
    public static class IJSExtensions {

        public static ValueTask<object> GuardarComo(this IJSRuntime js, string nombreArchivo, byte[] archivo) {

            return js.InvokeAsync<object>("saveAsFile" , nombreArchivo , Convert.ToBase64String(archivo));
        }

        public static ValueTask<object> MostrarMensaje(this IJSRuntime js, string mensaje) {

            return js.InvokeAsync<object>("Swal.fire" , mensaje);

        }

        public static ValueTask<object> MostrarMensaje(this IJSRuntime js ,  string titulo, string mensaje, TipoMensaje tipoMensaje) {

            return js.InvokeAsync<object>("Swal.fire" , titulo, mensaje, tipoMensaje.ToString());

        }
        
        public enum TipoMensaje {
            question, warning, error, success, info
        }

    }
}
