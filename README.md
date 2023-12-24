# Objective

Create controllers for all Entities, add CRUD operations for them.

# Improvements

I want to add some improvements to project we developed together in the lecture. 

## Refactor Duplicate BaseEntity Configuration Codes

The code block shown with blue was duplicate for all entity configuration classes.

<img width="1294" alt="DuplicatedConfigurations" src="https://github.com/300-Akbank-Net-Bootcamp/aw-2-CanberkTimurlenk/assets/18058846/05013527-e664-426b-b72f-3ff005eb30a4">

To prevent duplication a base entity configuration class, implementing a virtual ``Configure`` method, was introduced to allow its child classes to override.

```cs
 public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
 {
     // The base configuration for all entities, which will be overridden by the child classes
     public virtual void Configure(EntityTypeBuilder<TEntity> builder)
     {
         builder.Property(x => x.InsertDate).IsRequired(true);
         builder.Property(x => x.InsertUserId).IsRequired(true);
         builder.Property(x => x.UpdateDate).IsRequired(false);
         builder.Property(x => x.UpdateUserId).IsRequired(false);
         builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);
     }
 }
```

Child classes override the virtual method and call the Configure method of the base class within their own implementations.

```cs
public class ContactConfiguration : BaseEntityConfiguration<Contact>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        // Apply base configuration
        base.Configure(builder);

//codes...
```

<hr>

## Apply All Entity Type Configurations In the Executing Assembly

The DbContext was the place where the entity configurations was applied.

```bash
/Vb.Data/DbContext/VbDbContext.cs
```

The code we have written together includes the following lines to apply entity type configurations.

```cs
modelBuilder.ApplyConfiguration(new AccountConfiguration());
modelBuilder.ApplyConfiguration(new AccountTransactionConfiguration());
modelBuilder.ApplyConfiguration(new AddressConfiguration());
modelBuilder.ApplyConfiguration(new ContactConfiguration());
modelBuilder.ApplyConfiguration(new CustomerConfiguration());
modelBuilder.ApplyConfiguration(new EftTransactionConfiguration());
```

To keep the code concise, the following method was used.

```cs
modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
```

<hr>

## Create a Configuration Folder for Entity Type Configurations <br> 

A Configurations file was created under the Vb.Data

```bash
/Vb.Data/Configurations
```

All configuration classes have been moved to this folder.

<img width="400" alt="FolderStructure" src="https://github.com/300-Akbank-Net-Bootcamp/aw-2-CanberkTimurlenk/assets/18058846/987e9141-1c64-4960-be47-9f0922bf5f86">

<br>
<br>

# Endpoints
<details>
<summary>Click to display endpoints</summary>
<img width="898" alt="Endpoints" src="https://github.com/300-Akbank-Net-Bootcamp/aw-2-CanberkTimurlenk/assets/18058846/78c4ba4e-3ada-4c85-b5a6-47d4fadcb297">
</details>



[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/GfoSvSyx)
