   M S B A M L   `   `   `  ����H  DWPFPlayerDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPFPlayerDemoWPFPlayerDemo  5   	       WPFPlayerDemo.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WPFPlayerDemo     5   	   -   5          � Title$(  "iKu Player {$Version} 男的糊涂��5   	   $	��600��6,   $	��800��69    � Icon$ iKu.ico��6E    � 
ResizeMode$ CanMinimize=�6T    � WindowStartupLocation$ CenterScreen=�6m    J� 	AllowDrop . 
���   �$��Disabled=�6�      windowStyle#���   6�    � 	Resources 5	       �� Source�� 5
   
   $ mainWindowResources.xaml?�6   %     � Triggers 5      :� 5   
    :� RoutedEvent$ UIElement.MouseEnter��6   	 :� 
SourceName$	 Volume��6:   .[�5      �� -   5        
 ��Name$ 
 showVolume_BeginStoryboard��5        
showVolume#��[ 6B   5      :� 5   
   $ UIElement.MouseLeave��6   $	 Volume��6:   .[�5      �� -   5        $!
 hideVolume_BeginStoryboard1��5        
hideVolume#��[ 6C   5      .��5      �� -   5         ��Name$ MainBody��5       5   
     notifyIconMenu  notifyIconMenuStyle m�Name  notifyIconMenuItem  notifyIconMenuSeparator m� IsCheckable m� 	IsChecked��%�  &	       7  7  7  7  7  7  7  7  7  7  7  �� 5      8��  .@�5      m� $ menuPlay��6   -   5        $��播放��5   -   8�� 6R   m� 5      $ 	menuPause��6   -   5        $��暂停��5   .   $y�	Collapsed=�6T   8�� 6k   �� 5      8�� 6   m� 5      -   5        $��	上一曲��5      8�� 6A   m� 5      -   5        $��	下一曲��5      8�� 6A   �� 5      8�� 6   m� 5      $ menuDesktopLyric��6   -	   5        $��显示桌面歌词��5   5    .  . 8�� 6{   �� 5      8�� 6   m� 5       -
   5        $��关于��5       8��	 65   m� 5!      -   5        $��退出��5!      8��
 64   5"      5#      .+�5%   
   �� -   5         ��Name$ 
PlayButton��5%      $
��Play��6%   $��Center=�64   $	��100��6Q   $��Center=�6^   $	��100��6y   
 �� Top$	 392��6�    �� Left$	 343��6�     btnPlayStyle#���  6�    � Cursor$
 Hand��6�    � ToolTip$ 播放��6�   ��.   5&       �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels  btnAnimation J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Color   Opacity   
BlurRadius � Points��%l  &	       �� 5'      " ��6-   .�5(      ��  � ��$ Center=�6C   �� 5)       � ��$ Center=�6A   �� 5*       � ��$ 1q�60   �� 5+       � �� 5,      �� 5-      " ��6.   .R�5.   "   ��  . #���  6D    5/   &     50   *   $ 0Q�6;   $ White��6K   $ 1Q�6Y   $ 0Q�6e   .+�52   &   A� $
��Left=�6.   $	��100��6I   $��0q�6V   
�������$	��Top=�6p   $	��100��6�   $��5��6�   ���	#02FFFFFF6�   � 53   &    �   ������@x}
�������$��5��6W   $ 32.85��6k   $ 24.835��6   
�������6�   54   #   55      57      58      59      5:      �� 5<   
   -   5        $ PauseButton��5<      $��Pause��6&   $��Center=�66   $	��100��6S   $��Center=�6`   $	��100��6{   $	 392��6�   $	 343��6�    	 btnPauseStyle#��� 	 6�   $
 Hand��6�   $ 暂停��6�   $y�Hidden=�6�   ��.   5=      ��%�  &		       �� 5>      " ��6.   .�5?      ��  � ��$ Center=�6C   �� 5@       � ��$ Center=�6A   �� 5A       � ��$ 1q�60   �� 5B       � �� 5C      �� 5D      " ��6.   .R�5E   "   ��  . #���  6D    5F   &     5G   *   $ 0Q�6;   $ White��6K   $ 1Q�6Y   $ 0Q�6e   .+�5I   &   A� $
��Left=�6.   $	��100��6I   $��0q�6V   
�������$	��Top=�6p   $	��100��6�   $��5��6�   ���	#02FFFFFF6�   �� 5J   &   
�������$��54.33��6=   $ 26��6L   
�������$��5��6l   $ 24.835��6�   $��17��6�   �� 5K   &   
�������$��54.33��6=   $ 57��6L   
�������$��5��6l   $ 24.835��6�   $��17��6�   5L   #   5M      5O      5P      5Q      5R      �� 5T   
   -   5        $ 
LastButton��5T      $
��Last��6%   $��Center=�64   $��80��6Q   $��Center=�6]   $��80��6x   $	 402��6�   $	 153��6�    
 btnLastStyle#��� 
 6�   $
 Hand��6�   $ 	上一曲��6�   ��.   5U      ��%�  &	
       �� 5V      " ��6-   .�5W      ��  � ��$ Center=�6C   �� 5X       � ��$ Center=�6A   �� 5Y       � ��$ 1q�60   �� 5Z       � �� 5[      �� 5\      " ��6.   .R�5]   "   ��  . #���  6D    5^   &     5_   *   $ 0Q�6;   $ White��6K   $ 1Q�6Y   $ 0Q�6e   .+�5a   &   A� $
��Left=�6.   $��80��6I   $��0q�6U   
�������$	��Top=�6o   $��80��6�   $��5��6�   ���	#02FFFFFF6�   � 5b   &    �   `PZJ�PZJ
�������$��5��6^   $ 22.501��6r   
�������$ 10.985��6�   � 5c   &    �   `PZJ�PZJ
�������$��5��6^   $ 22.501��6r   
�������$ 41.319��6�   5d   #   5e      5g      5h      5i      5j      �� 5l   
   -   5        $ 
NextButton��5l      $
��Next��6%   $��Center=�64   $��80��6Q   $��Center=�6]   $��80��6x   $	 402��6�   $	 553��6�     btnNextStyle#���  6�   $
 Hand��6�   $ 	下一曲��6�   ��.   5m      ��%�  &	       �� 5n      " ��6-   .�5o      ��  � ��$ Center=�6C   �� 5p       � ��$ Center=�6A   �� 5q       � ��$ 1q�60   �� 5r       � �� 5s      �� 5t      " ��6.   .R�5u   "   ��  . #���  6D    5v   &     5w   *   $ 0Q�6;   $ White��6K   $ 1Q�6Y   $ 0Q�6e   .+�5y   &   A� $
��Left=�6.   $��80��6I   $��0q�6U   
�������$	��Top=�6o   $��80��6�   $��5��6�   ���	#02FFFFFF6�   � 5z   &    �   �PZJ`
�������$��5��6Z   $ 22.501��6n   
�������$ 17.332��6�   � 5{   &    �   �PZJ`
�������$��5��6Z   $ 22.501��6n   
�������$ 47.666��6�   5|   #   5}      5      5�      5�      5�      �� 5�   
   -   5        $ PlayListButton��5�      $��PlayList��6)   $��Center=�6<   $��40��6Y   $��Center=�6e   $��40��6�     btnPlayListStyle#���  6�   $
 Hand��6�   $ 播放列表��6�   ��.  $	 715��6�   $	 422��6�    5�      	 �� X1	  �� Y1	! �� X2	" �� Y2��%  &	       �� 5�      " ��61   .�5�      ��  � ��$ Center=�6C   �� 5�       � ��$ Center=�6A   �� 5�       � ��$ 1q�60   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   ��  . ���	#01000000.+�5�   &   �� 
�������$��5��6:   $ 0��6N   $  2��6U   $! 5��6\   $" 2��6c   �� 5�   &   
�������$��5��6:   $ 10��6N   $  2��6V   $! 40��6]   $" 2��6e   �� 5�   &   
�������$��5��6:   $ 0��6N   $  14��6U   $! 5��6]   $" 14��6d   �� 5�   &   
�������$��5��6:   $ 10��6N   $  14��6V   $! 40��6^   $" 14��6f   �� 5�   &   
�������$��5��6:   $ 0��6N   $  26��6U   $! 5��6]   $" 26��6d   �� 5�   &   
�������$��5��6:   $ 10��6N   $  26��6V   $! 40��6^   $" 26��6f   �� 5�   &   
�������$��5��6:   $ 0��6N   $  38��6U   $! 5��6]   $" 38��6d   �� 5�   &   
�������$��5��6:   $ 10��6N   $  38��6V   $! 40��6^   $" 38��6f   5�   #   5�      5�      5�      5�      5�      �� 5�   
   -   5        $ Spectrum��5�      $ 10��6#   $ 92��64   # J� IsHitTestVisible# .  $	��295��6]   $	��433��6j   .+�5�      �� -   5        $ ��Name$
$ ppt1��5�        spectrumArticleStyle#���  6&   $��1��6U   $	 1.1��6`   �� 5�      -   5        $
$ ppt2��5�      #���  6&   $��1��6U   $
 11.3��6`   �� 5�      -   5        $
$ ppt3��5�      #���  6&   $��1��6U   $
 21.5��6`   �� 5�      -   5        $
$ ppt4��5�      #���  6&   $��1��6U   $
 31.7��6`   �� 5�      -   5        $
$ ppt5��5�      #���  6&   $��1��6U   $
 41.9��6`   �� 5�      -   5        $
$ ppt6��5�      #���  6&   $��1��6U   $
 52.1��6`   �� 5�      -   5        $
$ ppt7��5�      #���  6&   $��1��6U   $
 62.3��6`   �� 5�      -   5        $
$ ppt8��5�      #���  6&   $��1��6U   $
 72.5��6`   �� 5�      -   5        $
$ ppt9��5�      #���  6&   $��1��6U   $
 82.7��6`   �� 5�      -   5        $$ ppt10��5�      #���  6'   $��1��6V   $
 92.9��6a   �� 5�      -   5        $$ ppt11��5�      #���  6'   $��1��6V   $ 103.1��6a   �� 5�      -   5        $$ ppt12��5�      #���  6'   $��1��6V   $ 113.3��6a   �� 5�      -   5        $$ ppt13��5�      #���  6'   $��1��6V   $ 123.5��6a   �� 5�      -   5        $$ ppt14��5�      #���  6'   $��1��6V   $ 133.7��6a   �� 5�      -    5        $$ ppt15��5�      #���  6'   $��1��6V   $ 143.9��6a   �� 5�      -!   5        $$ ppt16��5�      #���  6'   $��1��6V   $ 154.1��6a   �� 5�      -"   5        $$ ppt17��5�      #���  6'   $��1��6V   $ 164.3��6a   �� 5�      -#   5        $$ ppt18��5�      #���  6'   $��1��6V   $ 174.5��6a   �� 5�      -$   5        $$ ppt19��5�      #���  6'   $��1��6V   $ 184.7��6a   �� 5�      -%   5        $$ ppt20��5�      #���  6'   $��1��6V   $ 194.9��6a   �� 5�      -&   5        $$ ppt21��5�      #���  6'   $��1��6V   $ 205.1��6a   �� 5�      -'   5        $$ ppt22��5�      #���  6'   $��1��6V   $ 215.3��6a   �� 5�      -(   5        $$ ppt23��5�      #���  6'   $��1��6V   $ 225.5��6a   �� 5�      -)   5        $$ ppt24��5�      #���  6'   $��1��6V   $ 235.7��6a   �� 5�      -*   5        $$ ppt25��5�      #���  6'   $��1��6V   $ 245.9��6a   �� 5�      -+   5        $$ ppt26��5�      #���  6'   $��1��6V   $ 256.1��6a   �� 5�      -,   5        $$ ppt27��5�      #���  6'   $��1��6V   $ 266.3��6a   �� 5�      --   5        $$ ppt28��5�      #���  6'   $��1��6V   $ 276.5��6a   �� 5�      -.   5        $$ ppt29��5�      #���  6'   $��1��6V   $ 286.7��6a   �� 5�      -/   5        $$ ppt30��5�      #���  6'   $��1��6V   $ 296.9��6a   �� 5�      -0   5        $$ ppt31��5�      #���  6'   $��1��6V   $ 307.1��6a   �� 5�      -1   5        $$ ppt32��5�      #���  6'   $��1��6V   $ 317.3��6a   �� 5�      -2   5        $$ ppt33��5�      #���  6'   $��1��6V   $ 327.5��6a   �� 5�      -3   5        $$ ppt34��5�      #���  6'   $��1��6V   $ 337.7��6a   �� 5�      -4   5        $$ ppt35��5�      #���  6'   $��1��6V   $ 347.9��6a   �� 5�      -5   5        $$ ppt36��5�      #���  6'   $��1��6V   $ 358.1��6a   �� 5�      -6   5        $$ ppt37��5�      #���  6'   $��1��6V   $ 368.3��6a   �� 5�      -7   5        $$ ppt38��5�      #���  6'   $��1��6V   $ 378.5��6a   �� 5�      -8   5        $$ ppt39��5�      #���  6'   $��1��6V   $ 388.7��6a   �� 5�      -9   5        $$ ppt40��5�      #���  6'   $��1��6V   $ 398.9��6a   �� 5�      -:   5        $$ ppt41��5�      #���  6'   $��1��6V   $ 409.1��6a   �� 5�      -;   5        $$ ppt42��5�      #���  6'   $��1��6V   $ 419.3��6a   �� 5�      -<   5        $
$ ppx1��5�        spectralLineStyle#���  6&   % �� Bottom$% 2��6R   $��1��6d   $	 1.1��6o   �� 5�      -=   5        $
$ ppx2��5�      #���  6&   $% 2��6R   $��1��6d   $
 11.3��6o   �� 5�      ->   5        $
$ ppx3��5�      #���  6&   $% 2��6R   $��1��6d   $
 21.5��6o   �� 5�      -?   5        $
$ ppx4��5�      #���  6&   $% 2��6R   $��1��6d   $
 31.7��6o   �� 5�      -@   5        $
$ ppx5��5�      #���  6&   $% 2��6R   $��1��6d   $
 41.9��6o   �� 5�      -A   5        $
$ ppx6��5�      #���  6&   $% 2��6R   $��1��6d   $
 52.1��6o   �� 5�      -B   5        $
$ ppx7��5�      #���  6&   $% 2��6R   $��1��6d   $
 62.3��6o   �� 5�      -C   5        $
$ ppx8��5�      #���  6&   $% 2��6R   $��1��6d   $
 72.5��6o   �� 5�      -D   5        $
$ ppx9��5�      #���  6&   $% 2��6R   $��1��6d   $
 82.7��6o   �� 5�      -E   5        $$ ppx10��5�      #���  6'   $% 2��6S   $��1��6e   $
 92.9��6p   �� 5�      -F   5        $$ ppx11��5�      #���  6'   $% 2��6S   $��1��6e   $ 103.1��6p   �� 5�      -G   5        $$ ppx12��5�      #���  6'   $% 2��6S   $��1��6e   $ 113.3��6p   �� 5�      -H   5        $$ ppx13��5�      #���  6'   $% 2��6S   $��1��6e   $ 123.5��6p   �� 5�      -I   5        $$ ppx14��5�      #���  6'   $% 2��6S   $��1��6e   $ 133.7��6p   �� 5�      -J   5        $$ ppx15��5�      #���  6'   $% 2��6S   $��1��6e   $ 143.9��6p   �� 5�      -K   5        $$ ppx16��5�      #���  6'   $% 2��6S   $��1��6e   $ 154.1��6p   �� 5�      -L   5        $$ ppx17��5�      #���  6'   $% 2��6S   $��1��6e   $ 164.3��6p   �� 5�      -M   5        $$ ppx18��5�      #���  6'   $% 2��6S   $��1��6e   $ 174.5��6p   �� 5�      -N   5        $$ ppx19��5�      #���  6'   $% 2��6S   $��1��6e   $ 184.7��6p   �� 5�      -O   5        $$ ppx20��5�      #���  6'   $% 2��6S   $��1��6e   $ 194.9��6p   �� 5�      -P   5        $$ ppx21��5�      #���  6'   $% 2��6S   $��1��6e   $ 205.1��6p   �� 5�      -Q   5        $$ ppx22��5�      #���  6'   $% 2��6S   $��1��6e   $ 215.3��6p   �� 5�      -R   5        $$ ppx23��5�      #���  6'   $% 2��6S   $��1��6e   $ 225.5��6p   �� 5�      -S   5        $$ ppx24��5�      #���  6'   $% 2��6S   $��1��6e   $ 235.7��6p   �� 5�      -T   5        $$ ppx25��5�      #���  6'   $% 2��6S   $��1��6e   $ 245.9��6p   �� 5�      -U   5        $$ ppx26��5�      #���  6'   $% 2��6S   $��1��6e   $ 256.1��6p   �� 5�      -V   5        $$ ppx27��5�      #���  6'   $% 2��6S   $��1��6e   $ 266.3��6p   �� 5�      -W   5        $$ ppx28��5�      #���  6'   $% 2��6S   $��1��6e   $ 276.5��6p   �� 5�      -X   5        $$ ppx29��5�      #���  6'   $% 2��6S   $��1��6e   $ 286.7��6p   �� 5�      -Y   5        $$ ppx30��5�      #���  6'   $% 2��6S   $��1��6e   $ 296.9��6p   �� 5�      -Z   5        $$ ppx31��5�      #���  6'   $% 2��6S   $��1��6e   $ 307.1��6p   �� 5�      -[   5        $$ ppx32��5�      #���  6'   $% 2��6S   $��1��6e   $ 317.3��6p   �� 5�      -\   5        $$ ppx33��5�      #���  6'   $% 2��6S   $��1��6e   $ 327.5��6p   �� 5�      -]   5        $$ ppx34��5�      #���  6'   $% 2��6S   $��1��6e   $ 337.7��6p   �� 5�      -^   5        $$ ppx35��5�      #���  6'   $% 2��6S   $��1��6e   $ 347.9��6p   �� 5�      -_   5        $$ ppx36��5�      #���  6'   $% 2��6S   $��1��6e   $ 358.1��6p   �� 5�      -`   5        $$ ppx37��5�      #���  6'   $% 2��6S   $��1��6e   $ 368.3��6p   �� 5�      -a   5        $$ ppx38��5�      #���  6'   $% 2��6S   $��1��6e   $ 378.5��6p   �� 5�      -b   5        $$ ppx39��5�      #���  6'   $% 2��6S   $��1��6e   $ 388.7��6p   �� 5�      -c   5        $$ ppx40��5�      #���  6'   $% 2��6S   $��1��6e   $ 398.9��6p   �� 5�      -d   5        $$ ppx41��5�      #���  6'   $% 2��6S   $��1��6e   $ 409.1��6p   �� 5�      -e   5        $$ ppx42��5�      #���  6'   $% 2��6S   $��1��6e   $ 419.3��6p   5�      �� 5�   
   $ 10��6   $	 173��6"   # .  $	��766��6L   $	��214��6X   }�. $��Disabled=�6y   .+�5�      �� -f   5        & ��Name$	& Lrc��5�      # .  $	��766��6?   }�. $��Disabled=�6_    .   5�        5�      $ 0Q�6'   $ Black��67   $ 1Q�6E   $ 20Q�6Q   5�      5�      �� 5�   
   -g   5        ' ��Name$' 
TitleLabel��5�      $�� ��6$   $��77��6/   $ 10��6;   $ 10��6L   $	��766��6\   ���	#CCFFFFFF$��48(�6    5�        5�      $ 0Q�6#   $ Black��63   $ 1Q�6A   $ 20Q�6M   5     �� 5  
   -h   5        $' SingerLabel��5     $�� ��6%   $��50��60   $ 62��6<   $ 87��6M   $	��714��6]   ���	#CCFFFFFF$��29.333(�6�    5       5     $ 0Q�6#   $ Black��63   $ 1Q�6A   $ 20Q�6M   5     �� 5	  
   -i   5        $' 
AlbumLabel��5	     $�� ��6$   $��36��6/   $ 92��6;   $	 137��6L   $	��684��6]   ���	#CCFFFFFF$��18.667(�6�    5
       5     $ 0Q�6#   $ Black��63   $ 1Q�6A   $ 20Q�6M   5     �� 5  
   -j   5        ( ��Name$( 	TimeLabel��5     $��22��6'   $	 606��63   $	 507��6E   $	��170��6V   ���	#CCFFFFFF$��16(�6y   ) �� TextAlignment$) Right=�6�   �� 5  
   -k   5        * ��Name$* Progress��5     + J� Opacity$	+ 0.8Q�6#     SimpleSlider#���  61   $	��766��6X   $��14��6d   $ 10��6p   $	 534��6�   , � Maximum$, 10000Q�6�   - �� Orientation$- 
Horizontal=�6�   . � SmallChange$. 1Q�6�   / �� TickPlacement$
/ None=�6�   $
 Hand��6�   �� 5  
   -l   5        $ Volume��5     $��40��6!   $��40��6-   $ 31��68   $	 422��6I   ���	#00000000$	+ 0.9Q�6q   }�. .+�5     �� -m   5        $ 
MuteButton��5     $��Volume��6)   $��Center=�6:   $��40��6W   $��Center=�6c   $��40��6~     btnMuteStyle#���  6�   $
 Hand��6�   $ 静音��6�   ��.   5     ��%�  &	       �� 5     " ��61   .�5     ��  � ��$ Center=�6G   �� 5      � ��$ Center=�6E   �� 5      � ��$ 1q�64   �� 5      � �� 5     �� 5  "   " ��62   .R�5  &   ��  . #���  6H    5  *     5   .   $ 0Q�6?   $ White��6O   $ 1Q�6]   $ 0Q�6i   .+�5"  *   � 9 �   ��� ������ ��� -1 Zb -1��� ��� 
�������$��1��6k   
�������6   �� 5#  *   $��2��6/   
�������$ 25��6R   $  13��6Z   $! 40��6b   $" 4��6j   �� 5$  *   $��2��6/   
�������$ 25��6R   $  20��6Z   $! 40��6b   $" 20��6j   �� 5%  *   $��2��6/   
�������$ 25��6R   $  27��6Z   $! 40��6b   $" 36��6j   5&  '   5'  #   5)     5*     5+     5,     �� 5.     -n   5        $ VolumeButton��5.     $
��Mute��6+   $��Center=�6:   $��40��6W   $��Center=�6c   $��40��6~     btnVolumeStyle#���  6�   $
 Hand��6�   $ 取消静音��6�   ��.  $y�Hidden=�6�    5/     ��%�  &	       �� 50     " ��63   .�51     ��  � ��$ Center=�6G   �� 52      � ��$ Center=�6E   �� 53      � ��$ 1q�64   �� 54      � �� 55     �� 56  "   " ��62   .R�57  &   ��  . #���  6H    58  *     59  .   $ 0Q�6?   $ White��6O   $ 1Q�6]   $ 0Q�6i   .+�5;  *   � 9 �   ��� ������ ��� -1 Zb -1��� ��� 
�������$��1��6k   
�������6   A� 5<  *   $ 15��62   $	 7.5��6C   $
��Left=�6T   $��25��6o   $��0q�6{   
���  ��$	��Top=�6�   $��25��6�   $��4��6�   ���	#02FFFFFF6�   �� 5=  *   $��4��6/   
���  ��$ 20��6P   $  25��6X   $! 37��6`   $" 14��6h   5>  '   5?  #   5A     5B     5C     5D     �� 5F     -o   5        $* 	VolumeBar��5F     $	+ 0.8Q�6(   #���  66   $	��190��6]   $��14��6i   $	, 100Q�6u   $- 
Horizontal=�6�   $. 1Q�6�   $
/ None=�6�   $
 Hand��6�   $ 13��6�   $ 60��6�   0 � Value$	0 100Q�6�   6�   5G     �� 5I  
   -p   5        $ PlayList��5I     $ 10��6#   $	��392��64   $	��766��6A   ���	#CC000000$	+ 0.9Q�6d   }�. .+�5L     �� -q   5        1 ��Name$
1 List��5L     $	��342��6$   $ 10��61   $ 10��6B   $	��746��6R   ���	#4CFFFFFF
�������$��Disabled=�6�   $��Visible=�6�   2 �� SelectionMode$2 Extended=�6�   6   �� 5N     -r   5        3 ��Name$3 Model��5N     $��30��6&   $	 434��62   $	 357��6D   $	��106��6U   ���	#CCFFFFFF
������ $	+ 0.8Q�6�   4 �� 
IsReadOnly4 . 5 �� SelectedIndex$5 0��6�   $��20(�6�   $��Consolas)�6�   $��Disabled=�6�   $��Disabled=�6  .@�5O     �� $��列表循环��6   $��20(�6.   $��Consolas)�6<   $	+ 0.8Q�6R   $ 列表循环��6`   ��.  6o   �� 5P     $��顺序播放��6   $��20(�6.   $��Consolas)�6<   $	+ 0.8Q�6R   $ 顺序播放��6`   ��.  6o   �� 5Q     $��单曲循环��6   $��20(�6.   $��Consolas)�6<   $	+ 0.8Q�6R   $ 单曲循环��6`   ��.  6o   �� 5R     $��随机播放��6   $��20(�6.   $��Consolas)�6<   $	+ 0.8Q�6R   $ 随机播放��6`   ��.  6o   5S     �� 5U     -s   5        $ 	btnDelete��5U     $��30��6(   $	��145��64   $	 611��6@   $	 357��6R     btnStyle#���  6c   $��删除选中项��6�   $��隶书)�6�   $��24(�6�   $��0q�6�   ���	#CCFFFFFF 5V     6 � ColumnDefinitions7 �� Triggers8 P� Property9 P� Value��%�  &	       �� 5W     " ��6-   .�5X     ��  � ��$ 5,5,5,5q�63   �� 5Y      �@�Cursor$
 Hand��63   �� 5Z      �@J�Opacity$
 0.75Q�64   �� 5[      � �� 5\     �� 5]  "   " ��62   .R�5^  &   �� #��z��6-   
�������$��1q�6a   ���	#02FFFFFF._�5_  *   � 6 5`  .   �� 5a  2   $��20 �6C   �� 5b  2   $��* �6C   .+�5d  .   �� $��0��65   ._�5e  2   ]� .+�5f  6   �� $��15��6=   $��15��6H   $	��4,0q�6T   .+�5g  :   �� $��5��6?   
���  ��$ 0��6`   $  0��6g   $! 15��6n   $" 15��6v   �� 5h  :   $��5��6?   
���  ��$ 0��6`   $  15��6g   $! 15��6o   $" 0��6w   5i  7   5j  3   5k  /   �� 5l  .   $��1��65   $��Center=�6E   
������ $��Center=�6{   ._�5m  2   �� 5n  /   5o  +   5p  '   7 5q  &   P� 5r  *   8 �@J�IsMouseOver9 . . �5s  .   ��  �@J�Opacity$ 1Q�6H   5t  +   5v  #   5x     5y     5z     5{     5|     5~     5     