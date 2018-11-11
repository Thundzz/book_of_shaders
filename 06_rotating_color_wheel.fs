#ifdef GL_ES
precision mediump float;
#endif

#define TWO_PI 6.28318530718

uniform vec2 u_resolution;
uniform float u_time;

//  Function from Iñigo Quiles
//  https://www.shadertoy.com/view/MsS3Wc
vec3 hsb2rgb( in vec3 c ){
    vec3 rgb = clamp(abs(mod(c.x*6.0+vec3(0.0,4.0,2.0),
                             6.0)-3.0)-1.0,
                     0.0,
                     1.0 );
    rgb = rgb*rgb*(3.0-2.0*rgb);
    return c.z * mix( vec3(1.0), rgb, c.y);
}

void main(){
    vec2 st = gl_FragCoord.xy/u_resolution;   
    
    //st = rotmat*st;
    vec3 color = vec3(0.0);
	
    vec2 toCenter = st - vec2(.5);
    
    float angle= atan(toCenter.y, toCenter.x)/TWO_PI;
    float l = length(toCenter)*2.0;
    
    vec3 hsbColor = vec3(angle+u_time, l, 1.0);
    

    gl_FragColor = vec4(hsb2rgb(hsbColor),1.0);
}
