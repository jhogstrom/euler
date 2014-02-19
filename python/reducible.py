import math

primes = [2, 3, 5, 7]
def isprime(n):
	if n < 2:
		return False
	if n in primes:
		return True
	for i in range(2, int(math.sqrt(n)) + 1):
		if (n % i) == 0:
			return False

	primes.append(n)
	return True


def isreducible_left(n):
	s = str(n)
	for i in range(len(s)):
#		print "sub:",int(s[i:])
		if not isprime(int(s[i:])):
			return False

	#print "Left Redicible:", n
	return True

def isreducible_right(n):
	s = str(n)
	for i in range(len(s)):
#		print "sub:",int(s[:i+1])
		if not isprime(int(s[:i+1])):
			return False

	print "Right Redicible:", n
	return True

c = 10
red = []

print isreducible_left(1234)
print isreducible_right(1234)
#exit()
while True:
	if (isprime(c)):
		#print "prime:", c
		if isreducible_left(c) and isreducible_right(c):
			print "revesible: ", c
			red.append(c)
	c += 1
	if len(red) == 11:
		break

print "Sum:", sum(red), red