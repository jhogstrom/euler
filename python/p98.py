import math
words = open(r"words.txt").readline().replace('"', '').split(",")

# print len(words)
# print "[", words[len(words)-1], "]"

# for x in words:	
s = sorted([("".join(sorted(list(x))), x) for x in words])

def ispandigital(n):
	return len(set(list(str(n)))) == 9

# print ispandigital(123456789)

i = int(math.sqrt(100000000))
while True:
	i += 1
	v = i*i
	l = len(str(v))
	if ispandigital(v): print i, v
	if l > 9:
		break


for i in range(len(s)-1):
	if s[i][0] == s[i+1][0]:
		print s[i], s[i+1], len(s[i][0])

# print max([len(w) for w in words])
