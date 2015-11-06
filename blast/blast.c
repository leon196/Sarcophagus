#define true 1;
#define false 0;


typedef enum {
	END,
	REPEAT,
	CONTINUE
} CycleMode;

main (t)
{	
	
	
	CycleMode cycleMode = END;
	
	char* msg = "Yeah";

	
	
	int rate = 2048;
	int cnt = 0;
	int cycles = 16;
	int start = 0;
	
	float riser = 3;
	
	int skipAt = 2048/SPEED;
	
	int seqPos;
	int seqCount = 15;
	int curSeq = SEQ;
	static int seqSamples = 2048;
	static int seqLen = 32;
	static int seq[][32] = (int [][32]){
		{ 666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,  666,666,666,666,},
		{ 1,666,666,666, 6,666,666,666, 1,666,666,666, 6,666,666,666, 1,666,666,666, 6,666,666,666, 1,666,666,666, 6,666,666,666,},
		{ 1,2,7,666, 6,666,0,4, 1,666,7,2, 6,666,3,3, 1,666,7,666, 6,666,7,666, 1,666,7,666, 6,666,7,666,},
		{ 1,6,5,0, 6,666,4,4, 1,3,5,2, 6,666,3,3, 1,666,7,666, 6,666,7,666, 1,666,7,666, 6,666,7,666,},
		{ 1,6,5,0, 6,2,4,4, 1,3,5,2, 6,12,3,3, 1,1,5,1, 6,2,4,4, 1,3,5,12, 6,5,4,5,},
		{ 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5, 1,5,5,5, 1,5,4,5,},
		{ 1,0,0,1, 6,0,0,0, 1,0,0,1, 6,4,0,0, 1,0,0,1, 6,0,0,0, 1,2,3,4, 6,5,7,8,},
		{ 1,8,8,1, 6,8,8,8, 1,8,8,1, 6,5,8,8, 1,8,8,1, 6,8,8,8, 1,2,3,4, 6,5,7,0,},
		{ 1,0,0,0, 6,0,0,0, 1,0,0,0, 6,0,0,0, 1,0,0,0, 6,0,0,0, 1,0,0,0, 6,0,0,0,},
		{ 1,8,8,8, 6,8,8,8, 1,8,8,8, 6,8,8,8, 1,8,8,8, 6,8,8,8, 1,8,8,8, 6,8,8,8,},
		{ 8,8,8,8, 8,8,8,8, 8,8,8,8, 8,8,8,8, 8,8,8,8, 8,8,8,8, 8,8,8,8, 8,8,8,8,},
		{ 9,9,9,9, 9,9,9,9, 9,9,9,9, 9,9,9,9, 9,9,9,9, 9,9,9,9, 9,9,9,9, 9,9,9,9,},
		{ 9,8,11,10, 9,8,11,10, 9,8,11,10, 9,8,11,10, 9,8,11,10, 9,8,11,10, 9,8,11,10, 9,8,11,10,},
		{ 9,9,9,9, 8,8,8,8, 11,11,11,11, 10,10,10,10, 9,9,9,9, 8,8,8,8, 11,11,11,11, 10,10,10,10,},
		{ 11,11,11,11, 11,11,11,11, 11,11,11,11, 11,11,11,11, 11,11,11,11, 11,11,11,11, 11,11,11,11, 11,11,11,11,}
		

	};
	
	char push;
	
	for(t=rate*start;;t++)
	{
		cnt++;
		switch (seq[curSeq][(seqPos/seqSamples)%seqLen]) {
			case 0:
				push = ((19&t>>4)*t*(t%4));
				break;
			case 8:
				push = ((19&t>>4)*t*(t%3));
				break;
			case 10:
				push = ((t&t>>2)-2|(19&t>>4)*t*(t%3)+(t/64));
				break;
			case 11:
				push = (t*(t&t>>4)-(t/128));
				break;
			case 9:
				push = (3*t*t+(t%1024>512?20:0));
				break;
			case 2:
				push = ((19&t>>2)*t*(t%8));
				break;
			case 3:
				push = ((42&t>>8)*t*(t%8));
				break;
			case 1:
				push = ((t&t>>4)-4);
				break;
			case 12:
				push = ((t&t>>4)-(t*3));
				break;
			case 4:
				push = ((19&t>>8)*t);
				break;
			case 5:
				push = ((19&t>>8)*t*2);
				break;
			case 6:
				push = (((t&t>>4)-4)|(t*t*t*t*t*t*t));
				break;
			case 7:
				push = (((t&t>>4)-(t*3))|(t*654654%3218));
				break;
			case 666:
				push = ((t&t>>4)-(t*3));
				break;
			case 667:
				push = ((t&t>>4)-(t*3));
				break;
		}
		
		putchar(push);

		if (t>=start*rate+cycles*rate)
			t = start * rate;
			
		if (t%rate>=skipAt)
		{
			t+=(rate-skipAt);
			seqPos+=(rate-skipAt);
			//skipAt = random()%2048;
		}
		
		if (seqPos%2048==0)
		{
			
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



