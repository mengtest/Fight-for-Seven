package com.FightforSeven.manager;

import org.apache.ibatis.session.SqlSession;

import com.FightforSeven.dto.Role;
import com.FightforSeven.mapper.RoleMapper;
import com.FightforSeven.protocol.CreateProtocol;
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
			
			int result_select = roleMapper.selectUsername(username);
			sqlSession.commit();
			if(result_select != 0){
				//角色名存在
				return CreateProtocol.Create_UsernameDK;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CreateProtocol.Create_UsernameOK;
	}
	
	public int getRole(String account){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			RoleMapper roleMapper = sqlSession.getMapper(RoleMapper.class);
			
			Role role = roleMapper.getRole(account);
			sqlSession.commit();
			if(role == null){
				//无角色
				return CreateProtocol.Create_RoleOK;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CreateProtocol.Create_RoleOK;
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
				return CreateProtocol.Create_Failed;
			}else{
				return CreateProtocol.Create_Succeed;
			}
			
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CreateProtocol.Create_Failed;
	} 
	
	public int updateRole(String account, int selectIndex, String username){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			RoleMapper roleMapper = sqlSession.getMapper(RoleMapper.class);
			
			Role role = new Role();
			role.setAccount(account);
			role.setSelectIndex(selectIndex);
			role.setUsername(username);
			int result_update = roleMapper.updateRole(role);
			if(result_update == 0){
				return CreateProtocol.Create_RoleDK;
			}else{
				return CreateProtocol.Create_RoleOK;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession!=null){
				sqlSession.close();
			}
		}
		return CreateProtocol.Create_RoleDK;
	}
}
