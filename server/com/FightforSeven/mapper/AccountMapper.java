package com.FightforSeven.mapper;

import com.FightforSeven.dto.Account;

/** 
 * @author  作者：littleredhat
 * @date 创建时间：2016年11月21日 下午10:52:36 
 * @version 1.0 
 *
 */
public interface AccountMapper {
	public String selectAccount(String account);
	public int insertAccount(Account account);
	public int updateAccount(Account account);
}
