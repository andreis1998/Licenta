﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LicentaPrototip.Models
{
    public class MyHouseModel
    {
        public string Temperature { get; set; }
        public bool IsLedIntensityAutomatic { get; set; }
        public int LowLimitTemperature { get; set; }
        public int HighLimitTemperature { get; set; }
        public float CurrentSetTemperature { get; set; }
    }
}