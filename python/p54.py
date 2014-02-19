import re


class Card():
	def __init__(self,s):
		self.value = self.mapcard(s)
		self.charval = s[0]
		self.suite = s[1]

	def mapcard(self, c):
		v = c[0]
		values = [2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
		names = "23456789TJQKA"
		return values[names.find(v)]

	def __lt__(self, other):
		return self.value < other.value

	def __str__(self):
		return self.charval + self.suite


class Hand():
	MAX = 100
	def __init__(self, cards):
		self.asstring =""
		for c in sorted(cards):
			self.asstring += c[0]
		self.cards = sorted([Card(c) for c in cards])

		self.value = self.calcValue()
#		for c in self.cards:
#			print c.value, c.suite
		print self	, self.value

	def __str__(self):
		s = ""
		for c in self.cards:
			s += str(c) + "-"
		return s[:-1]

	def calcValue(self):
		if self.royalflush():
			return self.MAX
		if self.straightflush():
			return self.MAX - 1
		if self.fourofakind():
			return self.MAX - 2
		if self.fullhouse():
			return self.MAX - 3
		if self.flush():
			return self.MAX - 4
		if self.straight():
			return self.MAX - 5
		if self.threeofakind():
			return self.MAX - 6
		if self.twopair():
			return self.MAX - 7
		if self.pair():
			return self.MAX - 8
		return 9

	def otherHighestCard(self, other):
		for i in reversed(range(5)):
			if self.cards[i] != other.cards[i]:
				print self.cards[i], "<", other.cards[i], "=",self.cards[i] < other.cards[i]
				return self.cards[i] < other.cards[i]
		print "*"*80,"\nALL CARDS EQUAL"
		return true

	def __lt__(self, other):
		if self.value == other.value:
			return self.otherHighestCard(other)
		return self.value < other.value


	def flush(self):
		s = self.cards[0].suite
		return len([c for c in self.cards if c.suite == s]) == 5

	def straightflush(self):
		return self.flush() and self.straight()

	def straight(self):
		return self.cards[0].value == self.cards[1].value - 1 and  self.cards[1].value == self.cards[2].value - 1 and  self.cards[2].value == self.cards[3].value - 1 and  self.cards[3].value == self.cards[4].value - 1 

	def royalflush(self):
		return self.straightflush() and self.cards[0].value == 10

	def fullhouse(self):
		return self.cards[0].value == self.cards[1].value == self.cards[2].value and self.cards[3].value == self.cards[4].value

	def fourofakind(self):
		return re.search(r"([23456789TJQKA])(\1)(\1)(\1)", self.asstring) != None

	def threeofakind(self):
		return re.search(r"([23456789TJQKA])(\1)(\1)", self.asstring) != None

	def pair(self):
		return re.search(r"([23456789TJQKA])(\1)", self.asstring) != None

	def twopair(self):
		return len(re.findall(r"([23456789TJQKA])(\1)", self.asstring)) == 2

def problem54():
	with open(r"c:\temp\poker.txt") as f:
		hands = f.readlines()

	c = 0
	for h in hands:
		h = h.strip().split()
		if Hand(h[:5]) > Hand(h[5:]):
			print "Player 1 wins"
			c += 1;
			if c == 10:
				pass
				#exit()
		print
	print "Player1 wins:", c
	exit()



print len(itertools.permutations([1, 2, 3]))
exit()	

problem54()
#print "123".find("a")
#c = Card("1S")
#print c.value
#exit()

class frep:
	def __repr__(self):
		return "foofoofoofoo"

class foo:
	def __str__(self):
		return "foofoofoofoo"
	

f = foo()
print "ddododod:",f
exit()

h = Hand(['TC', 'QC', 'KC', 'AC', 'JC'])
h = Hand(['TC', 'TC', 'TC', 'JC', 'JC'])
h = Hand(['TC', 'TC', 'AC', 'AC', 'TC'])
print "flush: ", h.flush()
print "straight: ", h.straight()
print "straightflush: ", h.straightflush()
print "royal: ", h.royalflush()
print "fullhouse: ", h.fullhouse()
print "fourofakind: ", h.fourofakind()
print "twopair: ", h.twopair()
print 1 == 1 == 1 == 1 == 2	
p = "123"
print p
print any([1])

s = "2A33"
m = re.search(r"([A-Z])(\1)(\1)", s)
m = re.search(r"([A-Z0-9])(\1)(\1)(\1)", s) 
m = re.findall(r"([23456789TJQKA])(\1)", s)
if len(m) == 2:
	print "match"#>>"+s[m.start():m.end()]+"<<"
else:
	print "no match"