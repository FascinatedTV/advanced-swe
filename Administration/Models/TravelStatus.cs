﻿using Database.DbObjects;

namespace Administration.Models;

public record TravelStatus : IPersistable
{
    [PrimaryKey]
    public string Code { get; private set; }
    public string Description { get; private set; }
}