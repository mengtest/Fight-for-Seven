package com.FightforSeven.model;

import java.util.List;

/**
 * @author ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��20�� ����11:21:34
 * @version 1.0
 *
 */
public class SocketModel {
	private int type;
	private int area;
	private int command;
	private List<String> message;

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public int getArea() {
		return area;
	}

	public void setArea(int area) {
		this.area = area;
	}

	public int getCommand() {
		return command;
	}

	public void setCommand(int command) {
		this.command = command;
	}

	public List<String> getMessage() {
		return message;
	}

	public void setMessage(List<String> message) {
		this.message = message;
	}
}
