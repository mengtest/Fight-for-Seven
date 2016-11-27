package com.FightforSeven.manager;

import org.apache.ibatis.session.SqlSession;

import com.FightforSeven.dto.Account;
import com.FightforSeven.mapper.AccountMapper;
import com.FightforSeven.protocol.CommandProtocol;
import com.FightforSeven.util.SqlSessionFactoryUtil;

/**
 * @author ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��22�� ����11:23:02
 * @version 1.0
 *
 */
public class AccountManager {
	private static AccountManager instance = new AccountManager();

	public static AccountManager getInstance() {
		return instance;
	}
	
	public int checkAccount(String account, String password){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			AccountMapper accountMapper = sqlSession.getMapper(AccountMapper.class);
			
			String password_server = accountMapper.getPassword(account);
			sqlSession.commit();
			if(password_server == null){  //�˺Ų�����
				return CommandProtocol.Login_InvalidAccount;
			}
			else if(!password_server.equals(password)){  //�������
				return CommandProtocol.Login_InvalidPassword;
			}else{
				return CommandProtocol.Login_Succeed;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession != null){
				sqlSession.close();
			}
		}
		return CommandProtocol.Login_Failed;
	}
	
	public int insertAccount(String account, String password){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			AccountMapper accountMapper = sqlSession.getMapper(AccountMapper.class);
			
			int result_select = accountMapper.isAccountExist(account);
			sqlSession.commit();
			if(result_select != 0){  //�˺��Ѵ���
				return CommandProtocol.Register_InvalidAccount;
			}
			
			Account a = new Account();
			a.setAccount(account);
			a.setPassword(password);
			int result_insert = accountMapper.insertAccount(a);
			sqlSession.commit();
			if(result_insert == 0){
				return CommandProtocol.Register_Failed;
			}else{
				return CommandProtocol.Register_Succeed;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession != null){
				sqlSession.close();
			}
		}
		return CommandProtocol.Register_Failed;
	}
	
	public int updateAccount(String account, String password, String password_new){
		SqlSession sqlSession = SqlSessionFactoryUtil.openSqlSession();
		try{
			AccountMapper accountMapper = sqlSession.getMapper(AccountMapper.class);
			
			int result_select = accountMapper.isAccountExist(account);
			sqlSession.commit();
			if(result_select == 0){  //�˺Ų�����
				return CommandProtocol.Reset_InvalidAccount;
			}
			
			int result_check = checkAccount(account, password);
			if(result_check != CommandProtocol.Login_Succeed){  //�������
				return CommandProtocol.Reset_InvalidPassword;
			}
			
			Account a = new Account();
			a.setAccount(account);
			a.setPassword(password_new);
			int result_update = accountMapper.updateAccount(a);
			sqlSession.commit();
			if(result_update == 0){
				return CommandProtocol.Reset_Failed;
			}else{
				return CommandProtocol.Reset_Succeed;
			}
		}catch(Exception ex){
			System.err.println(ex.getMessage());
			sqlSession.rollback();
		}finally{
			if(sqlSession != null){
				sqlSession.close();
			}
		}
		return CommandProtocol.Reset_Failed;
	}
}
