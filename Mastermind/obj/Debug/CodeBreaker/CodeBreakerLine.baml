   M S B A M L   `   `   `  ����E  AMastermind, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Mastermind.CommonMastermind.Common  5      ,    &Mastermind.CodeBreaker.CodeBreakerLine   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Mastermind.Common     5      .��5
      � -   5          �Name$  
ColorsGrid��5
       � RowDefinitions 5   
   �� 5      �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $��90 �6   �� 5      $��90 �6   �� 5      $��90 �6   �� 5      $��90 �6   �� 5      $��50 �6   �� 5      $	��110 �6   .+�5   
   �� -   5         ��Name$ Pos1Stck��5      $��0��6'   �� 5   
   -   5        $ Pos2Stck��5      $��1��6'   �� 5   
   -   5        $ Pos3Stck��5      $��2��6'   �� 5   
   -   5        $ Pos4Stck��5      $��3��6'   �� 5   
   -   5        $ CheckCodeStck��5      $��4��6,   6>   �� 5   
   -   5         ��Name$ okBtn��5      $��5��6!   $��50��62   $��25��6=   ���	#FFFF3F3F��5      �� 5       �� 
TargetType" ��6"   .R�5      �� $��
okBtnImage��6   $��/CodeBreaker/okBtn.png��6.    �� Triggers 5       P� 5!       P� Property �@J�IsMouseDirectlyOver P� Value . . �5"      �� 	 �� 
TargetName$	 
okBtnImage��6%   
 �� Property
 � �� �� Value$  /CodeBreaker/okBtnDown.png��5$      5%      5'      5)      5+      5,      