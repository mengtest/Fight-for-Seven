package com.FightforSeven.decoder;

import io.netty.handler.codec.LengthFieldBasedFrameDecoder;

/**
 * @author ���ߣ�littleredhat
 * @date ����ʱ�䣺2016��11��20�� ����11:24:19
 * @version 1.0
 *
 */
public class LengthDecoder extends LengthFieldBasedFrameDecoder {

	public LengthDecoder(int maxFrameLength, int lengthFieldOffset, int lengthFieldLength, int lengthAdjustment,
			int initialBytesToStrip) {
		super(maxFrameLength, lengthFieldOffset, lengthFieldLength, lengthAdjustment, initialBytesToStrip);
	}

}
