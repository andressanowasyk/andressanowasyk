﻿using System;
namespace desafio_framework.Models
{
    public class Album
    {
        private int Id { get => Id; set => Id = value; }
        private string Title { get => Title; set => Title = value; }

        public Album(int id, string title)
        {
            Id = id;
            Title = title;
        }

    }



}

