using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Application.Const;

public class Messages
{
    public const string TITLE_ERROR = "title cannot be empty";
    public const string DESCRIPTION_ERROR = "description is invalid";
    public const string QUESTIONLABEL_ERROR = "label cannot be empty";
    public const string QUESTIONTYPE_ERROR = "question type not supported";
    public const string QUESTIONCATEGORY_ERROR = "question category not supported";
}


public class ErrorCodes
{
    public const string INVALID_FORM = "Invalid.Form";
    public const string INVALID_QUESTION = "Invalid.Question";
}