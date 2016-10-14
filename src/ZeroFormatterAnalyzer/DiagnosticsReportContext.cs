using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Analyzer
{
    // Store multiple errors.
    internal class DiagnosticsReportContext
    {
        readonly List<Diagnostic> diagnostics = new List<Diagnostic>();
        readonly SyntaxNodeAnalysisContext context;

        readonly bool fromAnalysis;

        public IReadOnlyCollection<Diagnostic> StoredDiagnostics => diagnostics;

        public DiagnosticsReportContext(SyntaxNodeAnalysisContext context)
        {
            this.context = context;
            this.fromAnalysis = true;
        }

        public DiagnosticsReportContext(CodeFixContext context)
        {
            this.fromAnalysis = false;
        }

        public void Add(Diagnostic diagnostic)
        {
            diagnostics.Add(diagnostic);
        }

        public void ReportAll()
        {
            if (fromAnalysis)
            {
                foreach (var item in diagnostics)
                {
                    context.ReportDiagnostic(item);
                }
            }
        }
    }
}
