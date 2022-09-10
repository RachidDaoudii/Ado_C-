﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFM_ADO
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EmployeService")]
	public partial class EmployeServiceDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Définitions de méthodes d'extensibilité
    partial void OnCreated();
    partial void InsertEmploye(Employe instance);
    partial void UpdateEmploye(Employe instance);
    partial void DeleteEmploye(Employe instance);
    partial void InsertService(Service instance);
    partial void UpdateService(Service instance);
    partial void DeleteService(Service instance);
    #endregion
		
		public EmployeServiceDataContext() : 
				base(global::EFM_ADO.Properties.Settings.Default.EmployeServiceConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public EmployeServiceDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EmployeServiceDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EmployeServiceDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EmployeServiceDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Employe> Employe
		{
			get
			{
				return this.GetTable<Employe>();
			}
		}
		
		public System.Data.Linq.Table<Service> Service
		{
			get
			{
				return this.GetTable<Service>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Employe")]
	public partial class Employe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Nom;
		
		private string _Prenom;
		
		private System.Nullable<System.DateTime> _DateNaissance;
		
		private System.Nullable<int> _IdService;
		
		private EntityRef<Service> _Service;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNomChanging(string value);
    partial void OnNomChanged();
    partial void OnPrenomChanging(string value);
    partial void OnPrenomChanged();
    partial void OnDateNaissanceChanging(System.Nullable<System.DateTime> value);
    partial void OnDateNaissanceChanged();
    partial void OnIdServiceChanging(System.Nullable<int> value);
    partial void OnIdServiceChanged();
    #endregion
		
		public Employe()
		{
			this._Service = default(EntityRef<Service>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nom", DbType="VarChar(50)")]
		public string Nom
		{
			get
			{
				return this._Nom;
			}
			set
			{
				if ((this._Nom != value))
				{
					this.OnNomChanging(value);
					this.SendPropertyChanging();
					this._Nom = value;
					this.SendPropertyChanged("Nom");
					this.OnNomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prenom", DbType="VarChar(50)")]
		public string Prenom
		{
			get
			{
				return this._Prenom;
			}
			set
			{
				if ((this._Prenom != value))
				{
					this.OnPrenomChanging(value);
					this.SendPropertyChanging();
					this._Prenom = value;
					this.SendPropertyChanged("Prenom");
					this.OnPrenomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateNaissance", DbType="Date")]
		public System.Nullable<System.DateTime> DateNaissance
		{
			get
			{
				return this._DateNaissance;
			}
			set
			{
				if ((this._DateNaissance != value))
				{
					this.OnDateNaissanceChanging(value);
					this.SendPropertyChanging();
					this._DateNaissance = value;
					this.SendPropertyChanged("DateNaissance");
					this.OnDateNaissanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdService", DbType="Int")]
		public System.Nullable<int> IdService
		{
			get
			{
				return this._IdService;
			}
			set
			{
				if ((this._IdService != value))
				{
					if (this._Service.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdServiceChanging(value);
					this.SendPropertyChanging();
					this._IdService = value;
					this.SendPropertyChanged("IdService");
					this.OnIdServiceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Service_Employe", Storage="_Service", ThisKey="IdService", OtherKey="IdService", IsForeignKey=true)]
		public Service Service
		{
			get
			{
				return this._Service.Entity;
			}
			set
			{
				Service previousValue = this._Service.Entity;
				if (((previousValue != value) 
							|| (this._Service.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Service.Entity = null;
						previousValue.Employe.Remove(this);
					}
					this._Service.Entity = value;
					if ((value != null))
					{
						value.Employe.Add(this);
						this._IdService = value.IdService;
					}
					else
					{
						this._IdService = default(Nullable<int>);
					}
					this.SendPropertyChanged("Service");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Service")]
	public partial class Service : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdService;
		
		private string _NomService;
		
		private EntitySet<Employe> _Employe;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdServiceChanging(int value);
    partial void OnIdServiceChanged();
    partial void OnNomServiceChanging(string value);
    partial void OnNomServiceChanged();
    #endregion
		
		public Service()
		{
			this._Employe = new EntitySet<Employe>(new Action<Employe>(this.attach_Employe), new Action<Employe>(this.detach_Employe));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdService", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IdService
		{
			get
			{
				return this._IdService;
			}
			set
			{
				if ((this._IdService != value))
				{
					this.OnIdServiceChanging(value);
					this.SendPropertyChanging();
					this._IdService = value;
					this.SendPropertyChanged("IdService");
					this.OnIdServiceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NomService", DbType="VarChar(50)")]
		public string NomService
		{
			get
			{
				return this._NomService;
			}
			set
			{
				if ((this._NomService != value))
				{
					this.OnNomServiceChanging(value);
					this.SendPropertyChanging();
					this._NomService = value;
					this.SendPropertyChanged("NomService");
					this.OnNomServiceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Service_Employe", Storage="_Employe", ThisKey="IdService", OtherKey="IdService")]
		public EntitySet<Employe> Employe
		{
			get
			{
				return this._Employe;
			}
			set
			{
				this._Employe.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Employe(Employe entity)
		{
			this.SendPropertyChanging();
			entity.Service = this;
		}
		
		private void detach_Employe(Employe entity)
		{
			this.SendPropertyChanging();
			entity.Service = null;
		}
	}
}
#pragma warning restore 1591
