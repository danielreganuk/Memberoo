using Microsoft.EntityFrameworkCore;
using Memberoo.Domain.Entities;

namespace Memberoo.Application.Interfaces;

public interface IMemberooContext
{
    DbSet<Member> Members { get; set; }

}