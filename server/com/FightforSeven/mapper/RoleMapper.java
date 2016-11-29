package com.FightforSeven.mapper;

import java.util.Map;

import com.FightforSeven.dto.Role;

/** 
 * @author  ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��25�� ����1:45:52 
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
