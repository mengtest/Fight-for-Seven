package com.FightforSeven.mapper;

import com.FightforSeven.dto.Account;

/** 
 * @author  ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��21�� ����10:52:36 
 * @version 1.0 
 *
 */
public interface AccountMapper {
	public int isAccountExist(String account);
	public String getPassword(String account);
	public int insertAccount(Account account);
	public int updateAccount(Account account);
}
