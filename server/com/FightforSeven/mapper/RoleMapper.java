package com.FightforSeven.mapper;

import java.util.Map;

import com.FightforSeven.dto.Role;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月25日 下午1:45:52 
 * @version 1.0 
 *
 */
public interface RoleMapper {
	public int isUsernameExist(String username);
	public int isRoleExist(String account);
	public Role getRoleInfo(String account);
	public int insertRole(Role role);
	public int updateUsername(Map<String, String> params);
}
