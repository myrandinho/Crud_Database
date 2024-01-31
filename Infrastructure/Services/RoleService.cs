

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class RoleService
{
    private readonly RoleRepository _roleRepository;

    public RoleService(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }




    public RoleEntity CreateRole(string roleName)
    {
        try
        {
            var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
            roleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });
            if (roleEntity != null)
            {
                return roleEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;


    }

    public RoleEntity GetRoleByRoleName(string roleName)
    {
        try
        {
            var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
            if (roleEntity != null)
            {
                return roleEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public RoleEntity GetRoleById(int id)
    {
        try
        {
            var roleEntity = _roleRepository.Get(x => x.Id == id);
            if (roleEntity != null)
            {
                return roleEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public IEnumerable<RoleEntity> GetRoles()
    {
        try
        {
            var roles = _roleRepository.GetAll();
            if (roles != null)
            {
                return roles;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        try
        {
            var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
            if (updatedRoleEntity != null)
            {
                return updatedRoleEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool DeleteRole(int id)
    {
        try
        {
            if (id != 0)
            {
                _roleRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
