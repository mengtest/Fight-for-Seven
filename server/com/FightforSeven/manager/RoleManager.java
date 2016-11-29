package com.FightforSeven.manager;

import java.util.HashMap;
import java.util.Map;

import org.apache.ibatis.session.SqlSession;

import com.FightforSeven.dto.Role;
import com.FightforSeven.mapper.RoleMapper;
import com.FightforSeven.protocol.CommandProtocol;
import com.FightforSeven.util.SqlSessionFactoryUtil;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月25日 下午1:54:14 
 * @version 1.0 
 *
 */
public class RoleManager {
	private static RoleManager instance = new RoleManager();
	
	public static RoleManager getInstance(){
		return instance;
	}
	
	public int checkUsername(String username){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			RoleMapper roleMapper = sqlSession.getMapper(RoleMapper.class);
			
			int result_select = roleMapper.isUsernameExist(username);
			sqlSession.commit();
			if(result_select == 0){		
				return CommandProtocol.CreateRole_UsernameNonExist;
			}else{  //角色名存在
				return CommandProtocol.CreateRole_UsernameExist;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CommandProtocol.CreateRole_Failed;
	}
	
	public int checkRole(String account){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			RoleMapper roleMapper = sqlSession.getMapper(RoleMapper.class);
			
			int result_select = roleMapper.isRoleExist(account);
			sqlSession.commit();
			if(result_select == 0){		
				return CommandProtocol.GetRole_RoleNonExist;
			}else{  //角色名存在
				return CommandProtocol.GetRole_RoleExist;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CommandProtocol.GetRole_Failed;
	}
	
	public Role getRoleInfo(String account){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			RoleMapper roleMapper = sqlSession.getMapper(RoleMapper.class);
			
			Role role = roleMapper.getRoleInfo(account);
			sqlSession.commit();
			if(role == null){  //无角色			
				return null;
			}else{
				return role;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return null;
	}
	
	public int insertRole(String account, int selectIndex, String username){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			RoleMapper roleMapper = sqlSession.getMapper(RoleMapper.class);
			
			Role role = new Role();
			role.setAccount(account);
			role.setSelectIndex(selectIndex);
			role.setUsername(username);
			int result_insert = roleMapper.insertRole(role);
			sqlSession.commit();
			if(result_insert == 0){
				return CommandProtocol.CreateRole_Failed;
			}else{
				return CommandProtocol.CreateRole_Succeed;
			}
			
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CommandProtocol.CreateRole_Failed;
	} 
	
	public int updateUsername(String account, String username){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			RoleMapper roleMapper = sqlSession.getMapper(RoleMapper.class);
			
			Map<String, String> params = new HashMap<String, String>();
			params.put("account", account);
			params.put("username", username);
			int result_update = roleMapper.updateUsername(params);
			if(result_update == 0){
				return CommandProtocol.UpdateRole_Failed;
			}else{
				return CommandProtocol.UpdateRole_Succeed;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CommandProtocol.UpdateRole_Failed;
	}
}
