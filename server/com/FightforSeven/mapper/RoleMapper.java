package com.FightforSeven.mapper;

import com.FightforSeven.dto.Role;

/** 
 * @author  ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��25�� ����1:45:52 
 * @version 1.0 
 *
 */
public interface RoleMapper {
	public int selectUsername(String username);
	public Role getRole(String account);
	public int insertRole(Role role);
	public int updateRole(Role role);
}
