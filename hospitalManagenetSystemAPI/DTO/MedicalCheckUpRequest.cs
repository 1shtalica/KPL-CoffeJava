﻿using hospitalManagenetSystemAPI.Models;

namespace hospitalManagenetSystemAPI.DTO
{
    public class MedicalCheckUpRequest
    {
        public int MedicalChekUpId { get; set; }
        public DateOnly date { get; set; }
        public string NoteMedicalChekup { get; set; }
        public string Result { get; set; }
    }
}
