﻿using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Users;

/// <summary>
/// The UserRole class represents the UserRole entity that contains properties for User role,
/// such as:
/// Name
/// </summary>
public class UserRole : Auditable
{
    public string Name { get; set; }
}