﻿using System;
namespace EstadoCuenta.INFRASTRUCTURE.Data
{
    public class BaseReponseGeneric<T>
    {
        public bool succcess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<BaseError>? Errors { get; set; }
    }
}
