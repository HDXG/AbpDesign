--角色菜单/权限表
create table SysRoleMenu(
	Id uniqueidentifier primary key not null,
	RoleId uniqueidentifier not null,
	MenuId uniqueidentifier not null,
	IsDelete bit not null,
	CreateTime datetime not null
)
--角色表
create table SysRole(
	Id uniqueidentifier primary key not null,
	RoleName nvarchar(200) not null,
	Note nvarchar(200) ,
	IsDefault bit not null,
	IsStatus bit not null,
	Order int not null,
	IsDelete bit not null,
	CreateTime datetime not null
)
--用户角色表
create table SysUserRole(
	Id uniqueidentifier primary key not null,
	UserId uniqueidentifier not null,
	RoleId uniqueidentifier not null,
	IsDelete bit not null,
	CreateTime datetime not null
)