

#define true 1;
#define false 0;

typedef enum {
	END,
	REPEAT,
	CONTINUE
} CycleMode;

main (t)
{
	
	CycleMode cycleMode = CONTINUE;
	
	int rate = 2048;
	int cnt = 0;
	int cycles = 16;
	int start = 0;
	
	int skipAt = 1024;
	
	int seqPos;
	int seqCount = 10;
	int curSeq = 0;
	static int seqSamples = 2048;
	static int seqLen = 32;
	static int seq[][32] = (int [][32]){
		{ 666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,},
		{ 1,666,666,666, 6,666,666,666, 1,666,666,666, 6,666,666,666, 1,666,666,666, 6,666,666,666, 1,666,666,666, 6,666,666,666,},
		{ 1,5,7,666, 6,666,0,4, 1,666,7,2, 6,666,3,3, 1,666,7,666, 6,666,7,666, 1,666,7,666, 6,666,7,666,},
		{ 1,6,5,0, 6,666,4,4, 1,3,5,2, 6,666,3,3, 1,666,7,666, 6,666,7,666, 1,666,7,666, 6,666,7,666,},
		{ 1,6,5,0, 6,2,4,4, 1,3,5,2, 6,12,3,3, 1,1,5,1, 6,2,4,4, 1,3,5,12, 6,5,4,5,},
		{ 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5,},
		{ 1,0,0,1, 6,0,0,0, 1,0,0,1, 6,4,0,0, 1,0,0,1, 6,0,0,0, 1,2,3,4, 6,5,7,8,},
		{ 1,8,8,1, 6,8,8,8, 1,8,8,1, 6,5,8,8, 1,8,8,1, 6,8,8,8, 1,2,3,4, 6,5,7,0,},
		{ 1,0,0,0, 6,0,0,0, 1,0,0,0, 6,0,0,0, 1,0,0,0, 6,0,0,0, 1,0,0,0, 6,0,0,0,},
		{ 1,8,8,8, 6,8,8,8, 1,8,8,8, 6,8,8,8, 1,8,8,8, 6,8,8,8, 1,8,8,8, 6,8,8,8,}

	};

	
	for(t=rate*start;;t++)
	{
		cnt++;
		switch (seq[curSeq][(seqPos/seqSamples)%seqLen]) {
			case 0:
				putchar((19&t>>4)*t*(t%4));
				break;
			case 8:
				putchar((19&t>>4)*t*(t%3));
				break;
			case 2:
				putchar((19&t>>2)*t*(t%8));
				break;
			case 3:
				putchar((42&t>>8)*t*(t%8));
				break;
			case 1:
				putchar((t&t>>4)-4);
				break;
			case 12:
				putchar((t&t>>4)-(t*3));
				break;
			case 4:
				putchar((19&t>>8)*t);
				break;
			case 5:
				putchar((19&t>>8)*t*2);
				break;
			case 6:
				putchar(((t&t>>4)-4)|(t*t*t*t*t*t*t));
				break;
			case 7:
				putchar(((t&t>>4)-(t*3))|(t*654654%3218));
				break;
			default:
				putchar((t&t>>4)-(t*3));
				break;
		}

		if (t>=start*rate+cycles*rate)
			t = start * rate;
			
		if (t%rate>=skipAt)
		{
			t+=(rate-skipAt);
			seqPos+=(rate-skipAt);
			//skipAt = random()%2048;
		}

		seqPos++;

		if (seqPos/seqSamples>=seqLen)
		{
			switch (cycleMode) {
				case END:
					return 0;
					break;
				case REPEAT:
					seqPos = 0;
					break;
				case CONTINUE:
					seqPos = 0;
					curSeq++;
					if (curSeq>=seqCount)
						return 0;
					break;
			}
		}
	}
}



