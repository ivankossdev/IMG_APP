def create_bmp():
    with open("test.bmp","w+b") as file:
        file.write(b'BM')#ID field (42h, 4Dh)
        file.write((154).to_bytes(4,byteorder="little"))#154 bytes (122+32) Size of the BMP file
        file.write((0).to_bytes(2,byteorder="little"))#Unused
        file.write((0).to_bytes(2,byteorder="little"))#Unused
        file.write((122).to_bytes(4,byteorder="little"))#122 bytes (14+108) Offset where the pixel array (bitmap data) can be found
        file.write((108).to_bytes(4,byteorder="little"))#108 bytes Number of bytes in the DIB header (from this point)
        file.write((4).to_bytes(4,byteorder="little"))#4 pixels (left to right order) Width of the bitmap in pixels
        file.write((2).to_bytes(4,byteorder="little"))#2 pixels (bottom to top order) Height of the bitmap in pixels
        file.write((1).to_bytes(2,byteorder="little"))#1 plane Number of color planes being used
        file.write((32).to_bytes(2,byteorder="little"))#32 bits Number of bits per pixel
        file.write((3).to_bytes(4,byteorder="little"))#3 BI_BITFIELDS, no pixel array compression used
        file.write((32).to_bytes(4,byteorder="little"))#32 bytes Size of the raw bitmap data (including padding)
        file.write((2835).to_bytes(4,byteorder="little"))#2835 pixels/metre horizontal Print resolution of the image,
        file.write((2835).to_bytes(4,byteorder="little"))#2835 pixels/metre vertical   72 DPI × 39.3701 inches per metre yields 2834.6472
        file.write((0).to_bytes(4,byteorder="little"))#0 colors Number of colors in the palette
        file.write((0).to_bytes(4,byteorder="little"))#0 important colors 0 means all colors are important
        file.write(b'\x00\x00\xFF\x00')#00FF0000 in big-endian Red channel bit mask (valid because BI_BITFIELDS is specified)
        file.write(b'\x00\xFF\x00\x00')#0000FF00 in big-endian Green channel bit mask (valid because BI_BITFIELDS is specified)
        file.write(b'\xFF\x00\x00\x00')#000000FF in big-endian Blue channel bit mask (valid because BI_BITFIELDS is specified)
        file.write(b'\x00\x00\x00\xFF')#FF000000 in big-endian Alpha channel bit mask
        file.write(b' niW')#little-endian "Win " LCS_WINDOWS_COLOR_SPACE
        file.write((0).to_bytes(36,byteorder="little"))#CIEXYZTRIPLE Color Space endpoints	Unused for LCS "Win " or "sRGB"
        file.write((0).to_bytes(4,byteorder="little"))#0 Red Gamma Unused for LCS "Win " or "sRGB"
        file.write((0).to_bytes(4,byteorder="little"))#0 Green Gamma Unused for LCS "Win " or "sRGB"
        file.write((0).to_bytes(4,byteorder="little"))#0 Blue Gamma Unused for LCS "Win " or "sRGB"
        file.write(b'\xFF\x00\x00\x7F')#255 0 0 127 Blue (Alpha: 127), Pixel (1,0)
        file.write(b'\x00\xFF\x00\x7F')#0 255 0 127 Green (Alpha: 127), Pixel (1,1)
        file.write(b'\x00\x00\xFF\x7F')#0 0 255 127 Red (Alpha: 127), Pixel (1,2)
        file.write(b'\xFF\xFF\xFF\x7F')#255 255 255 127 White (Alpha: 127), Pixel (1,3)
        file.write(b'\xFF\x00\x00\xFF')#255 0 0 255 Blue (Alpha: 255), Pixel (0,0)
        file.write(b'\x00\xFF\x00\xFF')#0 255 0 255 Green (Alpha: 255), Pixel (0,1)
        file.write(b'\x00\x00\xFF\xFF')#0 0 255 255 Red (Alpha: 255), Pixel (0,2)
        file.write(b'\xFF\xFF\xFF\xFF')#255 255 255 255 White (Alpha: 255), Pixel (0,3)
        file.close()
        
if __name__ == "__main__":
    print("Start")
    create_bmp()
    print("Stop")