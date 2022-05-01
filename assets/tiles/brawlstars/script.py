import glob
from bs4 import BeautifulSoup
import re

for file in glob.glob('*.svg'):
    with open(file, 'r') as s:
        data = s.read()
        soup = BeautifulSoup(data, features='html.parser')

    print(file)

    # edited = False

    # group = soup.find('svg').find('g').find('g')
    # if group is not None:
    #     style = group.get('style', '')
    #     if 'filter' in style:
    #         group['style'] = re.sub('filter:url\(.*?\).*?;?', '', style)
    #         print('non-needed filter in group')
    #         edited = True
    # else:
    #     obj = soup.find('svg').find('g')
    #     style = obj.get('style', '')
    #     if 'filter' in style:
    #         obj['style'] = re.sub('filter:url\(.*?\).*?;?', '', style)
    #         print('non-needed filter')
    #         edited = True

    # for c in soup.find_all('rect'):
    #     style = c.get('style', '')
    #     if 'filter' in style:
    #         c['style'] = re.sub('filter:url\(.*?\).*?;?', '', style)
    #         print('non-needed filter in rect')
    #         edited = True

    # if edited:
    #     with open(file, 'w') as s:
    #         s.write(str(soup))

    with open(file, 'w') as s:
        s.write(data.replace(';filter:url(#filter1957)', ''))
