using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Models;

namespace DynamicForm.Application.Interfaces.Data;

public interface IRepository
{
	void AddApplicationForm(ApplicationForm applicationForm);

	Task SaveApplicationFormAsync();
}
