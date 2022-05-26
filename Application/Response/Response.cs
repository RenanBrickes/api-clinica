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

    public class ResponsePaged<T> where T : class
    {
        
        public ResponsePaged(int total, int totalPage, int remaining, bool success, string mensage, T model = null)
        {
            Total = total;
            TotalPage = totalPage;
            Remaining = remaining;
            Success = success;
            Mensage = mensage;
            Model = model;
        }

        public int Total { get; set; }
        public int TotalPage { get; set; }
        public int Remaining { get; set; }
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
