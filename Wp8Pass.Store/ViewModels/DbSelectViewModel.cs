using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Wp8Pass.Store.Services;

namespace Wp8Pass.Store.ViewModels
{
    public class DbSelectViewModel : Screen
    {
        private readonly BindableCollection<DbSelectItemViewModel> _databases;
        private readonly IDatabaseManager _manager;

        /// <summary>
        /// Gets the databases.
        /// </summary>
        /// <value>
        /// The databases.
        /// </value>
        public IEnumerable<DbSelectItemViewModel> Databases
        {
            get { return _databases; }
        }

        /// <summary>
        /// Gets or sets the selected database.
        /// </summary>
        /// <value>
        /// The selected database.
        /// </value>
        public DbSelectItemViewModel SelectedDatabase { get; set; }

        public DbSelectViewModel(IDatabaseManager manager)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");

            _manager = manager;
            _databases = new BindableCollection<DbSelectItemViewModel>();
        }

        protected override async void OnInitialize()
        {
            var databases = await _manager.GetDatabases();

            _databases.Clear();
            _databases.AddRange(databases
                .Select(x => new DbSelectItemViewModel
                {
                    Name = x.Name,
                }));
        }
    }
}