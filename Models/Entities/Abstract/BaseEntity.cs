﻿using System;

namespace RestFullAPI.Models.Entities.Abstract
{
    public enum Status { Active = 1, Modified, Passive}
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        DateTime _createDate = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get => _status; set => _status = value; }

        Status _status = Status.Active;
    }
}
