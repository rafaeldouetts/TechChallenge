﻿namespace TechChallenge.Identity.Models;
public class TokenModel
{
    public string? Token { get; set; }
    public DateTime ValidTo { get; set; }
    public Usuario Usuario { get; set; }
}
