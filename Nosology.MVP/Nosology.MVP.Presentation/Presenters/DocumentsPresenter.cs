﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.Engine;
using Escyug.Nosology.MVP.Presentation.Views;
using Escyug.Nosology.MVP.Presentation.ModelView;

namespace Escyug.Nosology.MVP.Presentation.Presenters
{
    public sealed class DocumentsPresenter
    {
        private readonly IDocumentsView _view;

        private readonly Dictionary<FileType, string> _iconSet;

        public DocumentsPresenter(IDocumentsView view)
        {
            _view = view;

            _iconSet = new Dictionary<FileType, string> 
            { 
                {FileType.defaultFile, "fa fa-file"},
                {FileType.doc, "fa fa-file-word-o"},
                {FileType.exe, "fa fa-file-o"},
                {FileType.exel, "file-excel-o"},
                {FileType.pdf, "file-pdf-o"},
                {FileType.txt, "file-text-o"}
            };

            _view.PageLoad += () => OnLoad();
        }

        private void OnLoad()
        {
            List<TemplateFile> filesList = null;
            var filesListMV = new List<TemplateFileMV>();

            try
            {
                filesList = TemplateFile.LoadDocuments();

                foreach (var file in filesList)
                {
                    filesListMV.Add(
                        new TemplateFileMV(
                           file.Id, file.Title, file.Link, file.Description, _iconSet[file.FileType]));
                }

            }
            finally
            {
                filesList = null;
            }
            
            _view.DocumentsList = filesListMV;
        }
    }
}