using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Response
{
    public class Response<T> where T : class 
    {
        public Response(bool success, string mensage, T model = null)
        {
            Success = success;
            Mensage = MensagemDefaut(mensage, success);
            Model = model;
        }

        public bool Success { get; set; }
        public string Mensage { get; set; }
        public T Model { get; set; }

        private string MensagemDefaut(string mensage, bool success)
        {
            if (string.IsNullOrEmpty(mensage))
                return success ? "Operação realizada com sucesso!" : "Não foi possível realizar a operação, tente novamente ou mais tarde.";
            return mensage;
        }
    }
}
