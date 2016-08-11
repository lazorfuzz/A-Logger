using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace Fun_Logger
{
    class CodeDom
    {
        public static bool Compile(string EXE_Name, string Source, string[] Resources = null)
        {
            CompilerParameters Parameters = new CompilerParameters();
            bool result = false;
            Parameters.GenerateExecutable = true;
            Parameters.OutputAssembly = EXE_Name;
            Parameters.ReferencedAssemblies.Add("System.dll");
            Parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            Parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            Parameters.CompilerOptions = " /target:winexe";
            if (Resources != null && Resources.Length > 0)
            {
                foreach (string res in Resources)
                {
                    Parameters.EmbeddedResources.Add(res);
                }
            }
            Dictionary<string, string> ProviderOptions = new Dictionary<string, string>();
            ProviderOptions.Add("CompilerVersion", "v2.0");
            Parameters.TreatWarningsAsErrors = false;

            CompilerResults cResults = new Microsoft.CSharp.CSharpCodeProvider(ProviderOptions).CompileAssemblyFromSource(Parameters, Source);

            if (cResults.Errors.Count > 0)
            {
                foreach (CompilerError CompilerError_loopVariable in cResults.Errors)
                {
                    CompilerError error = CompilerError_loopVariable;
                    MessageBox.Show("Error: " + error.ErrorText + " Line " + error.Line + " Error # " + error.ErrorNumber, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                result = false;
            }
            else if (cResults.Errors.Count == 0)
            {
                result = true;
            }

            return result;
        }
    }
}
