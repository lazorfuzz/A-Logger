﻿using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace CSharp_RAT_Example
{
    class CodeDom
    {
        public static bool Compile(string EXE_Name, string Source)
        {
            CodeDomProvider Compiler = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters Parameters = new CompilerParameters();
            CompilerResults cResults = default(CompilerResults);

            Parameters.GenerateExecutable = true;
            Parameters.OutputAssembly = EXE_Name;
            Parameters.ReferencedAssemblies.Add("System.dll");
            Parameters.CompilerOptions = " /target:winexe";
            Parameters.TreatWarningsAsErrors = false;

            cResults = Compiler.CompileAssemblyFromSource(Parameters, Source);

            if (cResults.Errors.Count > 0)
            {
                foreach (CompilerError CompilerError_loopVariable in cResults.Errors)
                {
                    CompilerError error = CompilerError_loopVariable;
                    MessageBox.Show("Error: " + error.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else if (cResults.Errors.Count == 0)
            {
                return true;
            }
            return true;
        }
    }
}
