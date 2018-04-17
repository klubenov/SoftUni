using System;
using System.Collections.Generic;
using System.Text;


public interface ILeutenantGeneral : IPrivate
{
    List<Private> PrivatesList { get; }
}

