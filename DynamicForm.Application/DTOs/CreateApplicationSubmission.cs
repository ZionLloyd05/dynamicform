using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.DTOs;

public class CreateApplicationSubmission
{
    public ICollection<UserData> UserData { get; set; } = new List<UserData>();
}
