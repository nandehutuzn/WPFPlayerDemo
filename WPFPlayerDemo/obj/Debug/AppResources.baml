   M S B A M L   `   `   `  ����H  DWPFPlayerDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPFPlayerDemoWPFPlayerDemo  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   	winCorner  �� 
BottomLeft �� BottomRight �� TopLeft �� TopRight  winBorderStyle �� 
TargetType �� Property �� Value  winTitleCorner  winTitleStyle  btnMinimizeStyle �� 
TargetType J� Opacity	 �� RadiusY
 �� RadiusX	 �� X1	 �� X2	 �� Y1	 �� Y2 �� Triggers P� Property P� Value  btnCloseStyle A�Name  btnAnimation �� 	Resources  Key �� TargetProperty O� KeyTime O� Value �� Triggers :� RoutedEvent ��Name  mouseIn 	 mouseOut 
 DisabledBackgroundBrush �� Color  DisabledBorderBrush  
GlyphBrush  MouseOverBrush �� EndPoint �� 
StartPoint � Color � Offset  NormalBorderBrush  NormalBrush ! SimpleScrollRepeatButtonStyle  SimpleSliderThumb � 	Resources  �� 
TargetName! J� Effect3   -System.Windows.Media.Effects.DropShadowEffect"    ShadowDepth#    Color$    Opacity%    
BlurRadius& N� ExitActions' N� EnterActions( �� 
TargetName  SimpleSlider) �Name* � RowDefinitions+ m�Name, J� SnapsToDevicePixels- m� 	Placement. m� Fill/ ��Name0 �� CornerRadius1 ]�Name2 ]� Thumb3 ]� IncreaseRepeatButton4 ]� DecreaseRepeatButton5 �� Angle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      %localclr-namespace:WPFPlayerDemo  5      %  &	        &	 [     &	 �     &	     &	 &    &	 A    &	 �    7  7 	 &	
     &	 "    &	 @    &	 ^    &	 �    &	 �    &	     &	 d    7 	 7  &	     �� 5      $  5Q�5   =   $ 5Q�5	   ?   $ 5Q�5
   7   $ 5Q�5   9   5      �� 5      " ��6#   .�5   
   ��  � �� �	#000000006'   5      �� 5      $  0Q�5   =   $ 0Q�5   ?   $ 5Q�5   7   $ 5Q�5   9   5      �� 5      " ��6"   .�5   
   ��  �@�Cursor$
 Hand��6#   �� 5   
    � ��$
 Auto��6"   �� 5   
    � ��$ 28��6#   �� 5   
    � ��$	 Top=�6+   �� 5   
    �@�Cursor$
 Hand��6#   �� 5   
    �@��Padding$ 	10,5,10,5q�6$   5       �� 5"      " ��6%   .�5#   
   ��  � ��$ 2,0,2,0q�6#   �� 5$   
    �@�Cursor$
 Hand��6#   �� 5%   
    �@J�Opacity$
 0.75Q�6$   �� 5&   
    �@�ToolTip$ 	最小化��6$   �� 5'   
    � �� 5(      �� 5)      " ��6"   .R�5*      � .+�5+      �� $��16��6$   
�������$ .1Q�6<   $	 4��6I   $
 4��6U   $��2��6a   �� 5,      $��16��6$   $��2��6/   $
 4��6C   $	 4��6O   
�������6[   � 5.      .+�5/      �� $
��Left=�6%   $	��Top=�6@   $��5q�6X   .+�50   "   �� $��2��6'   
�������$ 0��6J   $ 8��6Q   $ 4��6X   $ 4��6_   51      52      53       54      P� 55       �@J�IsMouseOver . . �56      ��  �@J�Opacity$ 1Q�68   57      59      5;      5<      �� 5>      " ��6"   .�5?   
   ��  � ��$ 2,0,2,0q�6#   �� 5@   
    �@�Cursor$
 Hand��6#   �� 5A   
    �@J�Opacity$
 0.75Q�6$   �� 5B   
    �@�ToolTip$ 关闭��6$   �� 5C   
    � �� 5D      �� 5E      " ��6"   .R�5F      � .+�5G      A� $��18��6"   $��18��6-   $ .1Q�69   $��2��6F   ���#4f535d
�������6i   A� 5H      $ 	borderBtn��6"   $��18��65   $��18��6@   $��2��6L   
�������6`   � 5J      .+�5K      �� $
��Left=�6%   $	��Top=�6@   $��5q�6X   .+�5L   "   �� $��2��6'   
�������$ 0��6J   $ 0��6Q   $ 8��6X   $ 8��6_   �� 5M   "   $��2��6'   
�������$ 0��6J   $ 8��6Q   $ 8��6X   $ 0��6_   5N      5O      5P       5Q      P� 5R       �@J�IsMouseOver . . �5S      ��  �@J�Opacity$ 1Q�68   5T      5V      5X      5Y      �� 5[      " ��6!    5\   
   ���� 5^      mouseIn .��5_      U� $ Effect.BlurRadius�60   .\�5`      �� $ 0��6+   $ 20Q�67   5a      5b      �� 5d      mouseOut .��5e      U� $ Effect.BlurRadius�60   .\�5f      �� $ 0��6+   $ 0Q�67   5g      5h      5i       5j   
   :� 5k      $ UIElement.MouseEnter��6   .[�5l      �� $ mouseIn_BeginStoryboard��6"   8��  6C   5m      :� 5n      $ UIElement.MouseLeave��6   .[�5o      �� $ mouseOut_BeginStoryboard��6"   8�� 6D   5p      5r      �� 5u      $
 #EEE��66   �� 5v      $
 #AAA��62   �� 5x      $
 #444��6)   �� 5z      $	 0,1&�61   $	 0,0&�6@   .��5{   
   � $
 #FFF��6   $	 0.0Q�6$   � 5|   
   $
 #AAA��6   $	 1.0Q�6$   5}      �� 5      $	 0,1&�64   $	 0,0&�6C   .��5�   
   � $
 #CCC��6   $	 0.0Q�6$   � 5�   
   $
 #444��6   $	 1.0Q�6$   5�      �� 5�      $	 0,1&�6.   $	 0,0&�6=   .��5�   
   � $
 #EEE��6   $	 0.0Q�6$   � 5�   
   $
 #CCC��6   $	 1.0Q�6$   5�      �� 5�      " ��63   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � ��
 ���� 6(   �� 5�   
    � �� .  6&   �� 5�   
    � |� .  6&   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� #��z��6$   #��z��6H   #��z��6o   5�      5�      5�      5�      �� 5�      " n�6'   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��$ 14��6#   �� 5�   
    � ��$ 14��6"   �� 5�   
    � �� 5�      �� 5�      " n�6"    5�      ���� 5�      mouseIn .��5�      U� $6 0(UIElement.Effect).(DropShadowEffect.BlurRadius)�6<   $  Ellipse��6�   .\�5�   "   �� $ 0:0:0.1��67   $ 20Q�6I   5�      5�      �� 5�      mouseOut .��5�      U� $6 0(UIElement.Effect).(DropShadowEffect.BlurRadius)�6<   $  Ellipse��6�   .\�5�   "   �� $ 0��67   $ 20Q�6C   �� 5�   "   $ 0:0:0.5��67   $ 0Q�6I   5�      5�      5�      .R�5�      � .+�5�      A� $ Ellipse��6"   #���  63   #���  6X   $��1��6�   ! 5�         5�   "   $" 0Q�63   $# White��6C   $$ 1Q�6Q   $% 0Q�6]   5�      5�       5�      P� 5�       �@J�IsMouseOver . & 5�      �� 5�   "   $ mouseOut_BeginStoryboard��62   8��  6T   ' 5�      �� 5�   "   8�� 62   . �5�      �� # �  65   $( Ellipse��6^    � ��5�      P� 5�       � {� .  . �5�      �� # � 
 65   $( Ellipse��6g    � ��5�      5�      5�      5�      �� 5�      " ��6!   .�5�   
   ��  � �� �	#FF5151516'   �� 5�   
    � ��
 �   �6(   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � $) GridRoot��6   * 5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   #��z��6:   �� 5�      $
��Auto �6,   .+�5�      m� $+ TopTick��69   $y�	Collapsed=�6"   $��4��6J   , . $	- Top=�6p   #. �  6�   �� 5�      $/ Border��69   $��1��6!   $��0q�6.   $��4��6I   #��z��6T   #��z��6~   #��z��6�   $0 2��6�   ]� 5�      $1 
PART_Track��6-   $��1��6    2 5�      n� 5�   "   #���  6(   3 5�      �� 5�   "   #���  6/   $��Slider.IncreaseLarge��6g   4 5�      �� 5�   "   #���  6/   $��Slider.DecreaseLarge��6g   5�      m� 5�      $+ 
BottomTick��6F   $y�	Collapsed=�6"   $��2��69   $��4��6Z   , . $- Bottom=�6�   #. �  6�   5�       5�      P� 5�       �@��TickPlacement$ TopLeft=�6;   . �5�      �� $( TopTick��6K    � y�$ Visible=�6;   6K   5�      P� 5�       �@��TickPlacement$ BottomRight=�6;   . �5�      �� $( 
BottomTick��6K    � y�$ Visible=�6;   6K   5�      P� 5�       �@��TickPlacement$
 Both=�6;   . �5�      �� $( TopTick��6K    � y�$ Visible=�6;   6K   �� 5�      $( 
BottomTick��6K    � y�$ Visible=�6;   6K   5�      P� 5�       � {� .  . �5�      �� # � 
 6;   $( Border��6m    � ���� 5�      # �  6<   $( Border��6j    � ��5�      P� 5�       �@��Orientation$ Vertical=�69   . �5�      �� $( GridRoot��6@    �@�LayoutTransform 5�   "   �� 5�   &   $	5 -90Q�66   5�      �� 5�      $( 
PART_Track��6%    � ��$ 
Horizontal=�6T   5�      5�      5     �� 5  
    �@��Orientation$ Vertical=�6(   �� 5  
    �@�Maximum$ 10Q�6$   �� 5  
    �@�SmallChange$	 0.1Q�6(   �� 5  
    �@�Value$ 0Q�6"   �� 5  
    � |� .  6&   �� 5  
    � �� .  6&   �� 5  
    �@��TickPlacement$
 Both=�6*   5	     5     