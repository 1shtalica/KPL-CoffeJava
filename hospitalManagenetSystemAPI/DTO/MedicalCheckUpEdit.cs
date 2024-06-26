﻿using hospitalManagenetSystemAPI.Models;

namespace hospitalManagenetSystemAPI.DTO
{
    public class MedicalCheckUpEdit
    {
        public DateOnly date { get; set; }
        public string NoteMedicalChekup { get; set; }
        public string Result { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }
    }
}
