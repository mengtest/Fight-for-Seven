package com.FightforSeven.mapper;

import com.FightforSeven.dto.Role;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月25日 下午1:45:52 
 * @version 1.0 
 *
 */
public interface RoleMapper {
	public int selectUsername(String username);
	public Role getRole(String account);
	public int insertRole(Role role);
	public int updateRole(Role role);
}
